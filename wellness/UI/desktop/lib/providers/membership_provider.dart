import 'package:desktop/models/membership.dart';
import 'package:desktop/providers/base_provider.dart';

class MembershipProvider extends BaseProvider<Membership> {
  MembershipProvider() : super("Membership");

  @override
  Membership fromJson(data) {
    return Membership.fromJson(data);
  }
}
