import 'package:mobile/models/membership.dart';
import 'package:mobile/providers/base_provider.dart';

class MembershipProvider extends BaseProvider<Membership> {
  MembershipProvider() : super("Membership");

  @override
  Membership fromJson(data) {
    return Membership.fromJson(data);
  }
}
